import { Action } from '../actions/operators';
import { AxiosError } from 'axios';
import { IOperator } from '../interfaces/operator';

export enum ActionType {
  FETCH_OPERATORS_REQUEST = 'FETCH_OPERATORS_REQUEST',
  FETCH_OPERATORS_SUCCESS = 'FETCH_OPERATORS_SUCCESS',
  FETCH_OPERATORS_FAILURE = 'FETCH_OPERATORS_FAILURE'
}

export type State = {
  readonly isFetching: boolean;
  readonly operators: IOperator[] | null;
  readonly error: AxiosError | null;
};

export const initialState: State = {
  isFetching: false,
  operators: null,
  error: null
};

export function reducer(state: State = initialState, action: Action): State {
  switch (action.type) {
    case ActionType.FETCH_OPERATORS_REQUEST:
      return {
        ...state,
        isFetching: true
      };
    case ActionType.FETCH_OPERATORS_SUCCESS:
      return {
        isFetching: false,
        operators: action.payload,
        error: null
      };
    case ActionType.FETCH_OPERATORS_FAILURE:
      return {
        ...state,
        isFetching: false,
        error: action.error
      };
    default:
      return state;
  }
}
