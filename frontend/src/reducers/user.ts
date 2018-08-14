import { Action } from '../actions/user';
import { AxiosError } from 'axios';
import { IUser } from '../interfaces/user';

export enum ActionType {
  GET_LIVE_STATS = 'GET_LIVE_STATS',
  FETCH_USER_REQUEST = 'FETCH_USER_REQUEST',
  FETCH_USER_SUCCESS = 'FETCH_USER_SUCCESS',
  FETCH_USER_FAILURE = 'FETCH_USER_FAILURE'
}

export enum HubMethod {
  StartFetchMatch = 'StartFetchMatch',
  GetLiveStats = 'GetLiveStats'
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
    case ActionType.GET_LIVE_STATS:
      return {
        ...state,
        user: { ...state.user, stats: action.payload } as IUser
      };
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
