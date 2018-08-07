import axios, { AxiosError } from 'axios';
import hub from '../hub';
import { ActionType, HubMethod } from '../reducers/counter';
import { ICounter } from '../interfaces/counter';
import { RootState } from '../reducers';
import { Store } from 'redux';
import { ThunkAction } from 'redux-thunk';

export const increment = (payload: number) => ({
  type: ActionType.INCREMENT_COUNT as typeof ActionType.INCREMENT_COUNT,
  payload
});

export const decrement = (payload: number) => ({
  type: ActionType.DECREMENT_COUNT as typeof ActionType.DECREMENT_COUNT,
  payload
});

export const incrementCount = (): ThunkAction<void, RootState, null, Action> => () =>
  hub.invoke(HubMethod.IncrementCounter);

export const decrementCount = (): ThunkAction<void, RootState, null, Action> => () =>
  hub.invoke(HubMethod.DecrementCounter);

export const signalRRegisterCommands = async (store: Store, cb: () => void) => {
  hub.on(HubMethod.IncrementCounter, ({ count }) => store.dispatch(increment(count)));
  hub.on(HubMethod.DecrementCounter, ({ count }) => store.dispatch(decrement(count)));
  await hub.start();
  cb();
};

export const fetchCountRequest = () => ({
  type: ActionType.FETCH_COUNT_REQUEST as typeof ActionType.FETCH_COUNT_REQUEST
});

export const fetchCountSuccess = (payload: ICounter) => ({
  type: ActionType.FETCH_COUNT_SUCCESS as typeof ActionType.FETCH_COUNT_SUCCESS,
  payload
});

export const fetchCountFailure = (error: AxiosError) => ({
  type: ActionType.FETCH_COUNT_FAILURE as typeof ActionType.FETCH_COUNT_FAILURE,
  error
});

export const fetchCount = (): ThunkAction<void, RootState, null, Action> => async dispatch => {
  try {
    dispatch(fetchCountRequest());

    const response = await axios.get<ICounter>(`/api/counter`);

    dispatch(fetchCountSuccess(response.data));
  } catch (error) {
    dispatch(fetchCountFailure(error));
  }
};

export type Action =
  | ReturnType<typeof increment>
  | ReturnType<typeof decrement>
  | ReturnType<typeof fetchCountRequest>
  | ReturnType<typeof fetchCountSuccess>
  | ReturnType<typeof fetchCountFailure>;
