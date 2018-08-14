import { Action } from '../actions/killFeed';
import { AxiosError } from 'axios';
import { IKillFeed } from '../interfaces/killFeed';

export enum ActionType {
  GET_LIVE_KILLFEED = 'GET_LIVE_KILLFEED',
  FETCH_KILLFEED_REQUEST = 'FETCH_KILLFEED_REQUEST',
  FETCH_KILLFEED_SUCCESS = 'FETCH_KILLFEED_SUCCESS',
  FETCH_KILLFEED_FAILURE = 'FETCH_KILLFEED_FAILURE'
}

export enum HubMethod {
  GetLiveKillFeed = 'GetLiveKillFeed'
}

export type State = {
  readonly isFetching: boolean;
  readonly killFeed: IKillFeed | null;
  readonly error: AxiosError | null;
};

export const initialState: State = {
  isFetching: false,
  killFeed: null,
  error: null
};

export function reducer(state: State = initialState, action: Action): State {
  switch (action.type) {
    case ActionType.GET_LIVE_KILLFEED:
      return {
        ...state,
        killFeed:
          state.killFeed &&
          ({ ...state.killFeed, killFeedItems: [action.payload, ...state.killFeed.killFeedItems] } as IKillFeed)
      };
    case ActionType.FETCH_KILLFEED_REQUEST:
      return {
        ...state,
        isFetching: true
      };
    case ActionType.FETCH_KILLFEED_SUCCESS:
      return {
        isFetching: false,
        killFeed: action.payload,
        error: null
      };
    case ActionType.FETCH_KILLFEED_FAILURE:
      return {
        ...state,
        isFetching: false,
        error: action.error
      };
    default:
      return state;
  }
}
