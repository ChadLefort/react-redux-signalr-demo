import axios, { AxiosError } from 'axios';
import hub from '../hub';
import { ActionType, HubMethod } from '../reducers/killFeed';
import { IKillFeed, IKillFeedItem } from '../interfaces/killFeed';
import { RootState } from '../reducers';
import { Store } from 'redux';
import { ThunkAction } from 'redux-thunk';

export const getLiveKillFeed = (payload: IKillFeedItem) => ({
  type: ActionType.GET_LIVE_KILLFEED as typeof ActionType.GET_LIVE_KILLFEED,
  payload
});

export const fetchKillFeedRequest = () => ({
  type: ActionType.FETCH_KILLFEED_REQUEST as typeof ActionType.FETCH_KILLFEED_REQUEST
});

export const fetchKillFeedSuccess = (payload: IKillFeed) => ({
  type: ActionType.FETCH_KILLFEED_SUCCESS as typeof ActionType.FETCH_KILLFEED_SUCCESS,
  payload
});

export const fetchKillFeedFailure = (error: AxiosError) => ({
  type: ActionType.FETCH_KILLFEED_FAILURE as typeof ActionType.FETCH_KILLFEED_FAILURE,
  error
});

export const signalRCommands = (store: Store) =>
  hub.on(HubMethod.GetLiveKillFeed, (payload: IKillFeedItem | null) => {
    if (payload) {
      console.log(`Added kill feed item ${payload.killFeedItemId}.`);
      store.dispatch(getLiveKillFeed(payload));
    }
  });

export const fetchKillFeed = (
  killFeedId: number
): ThunkAction<Promise<IKillFeed>, RootState, null, Action> => async dispatch => {
  return new Promise<IKillFeed>(async (resolve, reject) => {
    try {
      dispatch(fetchKillFeedRequest());

      const { data } = await axios.get<IKillFeed>(`/api/killfeeds/${killFeedId}`);

      dispatch(fetchKillFeedSuccess(data));
      resolve(data);
    } catch (error) {
      console.error(error);
      dispatch(fetchKillFeedFailure(error));
      reject(error);
    }
  });
};

export type Action =
  | ReturnType<typeof getLiveKillFeed>
  | ReturnType<typeof fetchKillFeedRequest>
  | ReturnType<typeof fetchKillFeedSuccess>
  | ReturnType<typeof fetchKillFeedFailure>;
