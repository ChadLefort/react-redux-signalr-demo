import { Action } from '../actions/user';
import { AxiosError } from 'axios';
import { IUser } from '../interfaces/user';

export enum ActionType {
  INCREMENT_USER = 'INCREMENT_USER',
  DECREMENT_USER = 'DECREMENT_USER',
  FETCH_USER_REQUEST = 'FETCH_USER_REQUEST',
  FETCH_USER_SUCCESS = 'FETCH_USER_SUCCESS',
  FETCH_USER_FAILURE = 'FETCH_USER_FAILURE'
}

export enum HubMethod {
  IncrementCounter = 'IncrementCounter',
  DecrementCounter = 'DecrementCounter'
}

export type State = {
  readonly isFetching: boolean;
  readonly user: IUser | null;
  readonly error: AxiosError | null;
};

export const initialState: State = {
  isFetching: false,
  user: null,
  error: null
};

export function reducer(state: State = initialState, action: Action): State {
  switch (action.type) {
    // case ActionType.INCREMENT_USER:
    //   return {
    //     ...state,
    //     user: action.payload
    //   };
    // case ActionType.DECREMENT_USER:
    //   return {
    //     ...state,
    //     user: action.payload
    //   };
    case ActionType.FETCH_USER_REQUEST:
      return {
        ...state,
        isFetching: true
      };
    case ActionType.FETCH_USER_SUCCESS:
      return {
        isFetching: false,
        user: action.payload,
        error: null
      };
    case ActionType.FETCH_USER_FAILURE:
      return {
        ...state,
        isFetching: false,
        error: action.error
      };
    default:
      return state;
  }
}
