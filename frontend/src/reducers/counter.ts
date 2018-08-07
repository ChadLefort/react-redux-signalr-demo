import { Action } from '../actions/counter';
import { AxiosError } from 'axios';

export enum ActionType {
  INCREMENT_COUNT = 'INCREMENT_COUNT',
  DECREMENT_COUNT = 'DECREMENT_COUNT',
  FETCH_COUNT_REQUEST = 'FETCH_COUNT_REQUEST',
  FETCH_COUNT_SUCCESS = 'FETCH_COUNT_SUCCESS',
  FETCH_COUNT_FAILURE = 'FETCH_COUNT_FAILURE'
}

export enum HubMethod {
  IncrementCounter = 'IncrementCounter',
  DecrementCounter = 'DecrementCounter'
}

export type State = {
  readonly isFetching: boolean;
  readonly count: number;
  readonly error: AxiosError | null;
};

export const initialState: State = {
  isFetching: false,
  count: 0,
  error: null
};

export function reducer(state: State = initialState, action: Action): State {
  switch (action.type) {
    case ActionType.INCREMENT_COUNT:
      return {
        ...state,
        count: action.payload
      };
    case ActionType.DECREMENT_COUNT:
      return {
        ...state,
        count: action.payload
      };
    case ActionType.FETCH_COUNT_REQUEST:
      return {
        ...state,
        isFetching: true
      };
    case ActionType.FETCH_COUNT_SUCCESS:
      return {
        isFetching: false,
        count: action.payload.count,
        error: null
      };
    case ActionType.FETCH_COUNT_FAILURE:
      return {
        ...state,
        isFetching: false,
        error: action.error
      };
    default:
      return state;
  }
}
