import axios, { AxiosError } from 'axios';
import { ActionType } from '../reducers/operators';
import { IOperator } from '../interfaces/operator';
import { RootState } from '../reducers';
import { ThunkAction } from 'redux-thunk';

export const fetchOperatorsRequest = () => ({
  type: ActionType.FETCH_OPERATORS_REQUEST as typeof ActionType.FETCH_OPERATORS_REQUEST
});

export const fetchOperatorsSuccess = (payload: IOperator[]) => ({
  type: ActionType.FETCH_OPERATORS_SUCCESS as typeof ActionType.FETCH_OPERATORS_SUCCESS,
  payload
});

export const fetchOperatorsFailure = (error: AxiosError) => ({
  type: ActionType.FETCH_OPERATORS_FAILURE as typeof ActionType.FETCH_OPERATORS_FAILURE,
  error
});

const shouldFetchOperators = ({ operators: { isFetching, error, operators } }: RootState) =>
  !isFetching && !error && !operators;

const fetchOperators = (): ThunkAction<Promise<IOperator[]>, RootState, null, Action> => async dispatch => {
  return new Promise<IOperator[]>(async (resolve, reject) => {
    try {
      dispatch(fetchOperatorsRequest());

      const { data } = await axios.get<IOperator[]>('/api/operators');

      dispatch(fetchOperatorsSuccess(data));
      resolve(data);
    } catch (error) {
      dispatch(fetchOperatorsFailure(error));
      reject(error);
    }
  });
};

export const fetchOperatorsIfNeeded = (): ThunkAction<void, RootState, null, Action> => (dispatch, getState) => {
  if (shouldFetchOperators(getState())) {
    dispatch(fetchOperators());
  }
};

export type Action =
  | ReturnType<typeof fetchOperatorsRequest>
  | ReturnType<typeof fetchOperatorsSuccess>
  | ReturnType<typeof fetchOperatorsFailure>;
