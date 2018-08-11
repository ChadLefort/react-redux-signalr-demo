import axios, { AxiosError } from 'axios';
import hub from '../hub';
import { ActionType, HubMethod } from '../reducers/user';
import { IStats } from '../interfaces/stats';
import { IUser } from '../interfaces/user';
import { RootState } from '../reducers';
import { Store } from 'redux';
import { ThunkAction } from 'redux-thunk';

export const getLiveStats = (payload: IStats) => ({
  type: ActionType.GET_LIVE_STATS as typeof ActionType.GET_LIVE_STATS,
  payload
});

export const startFetchMatch = (userId: number): ThunkAction<void, RootState, null, Action> => () =>
  hub.invoke(HubMethod.StartFetchMatch, userId);

export const signalRRegisterCommands = async (store: Store, cb: () => void) => {
  hub.on(HubMethod.OnConnected, connectionId => console.log(`${connectionId} has connected to SignalR Hub.`));
  hub.on(HubMethod.OnDisconnected, connectionId => console.log(`${connectionId} has disconnected to SignalR Hub.`));
  hub.on(HubMethod.GetLiveStats, payload => store.dispatch(getLiveStats(payload)));

  await hub.start();
  cb();
};

export const fetchUserRequest = () => ({
  type: ActionType.FETCH_USER_REQUEST as typeof ActionType.FETCH_USER_REQUEST
});

export const fetchUserSuccess = (payload: IUser) => ({
  type: ActionType.FETCH_USER_SUCCESS as typeof ActionType.FETCH_USER_SUCCESS,
  payload
});

export const fetchUserFailure = (error: AxiosError) => ({
  type: ActionType.FETCH_USER_FAILURE as typeof ActionType.FETCH_USER_FAILURE,
  error
});

export const fetchUser = (userId: number): ThunkAction<Promise<IUser>, RootState, null, Action> => async dispatch => {
  return new Promise<IUser>(async (resolve, reject) => {
    try {
      dispatch(fetchUserRequest());

      const { data } = await axios.get<IUser>(`/api/users/${userId}`);

      dispatch(fetchUserSuccess(data));
      resolve(data);
    } catch (error) {
      dispatch(fetchUserFailure(error));
      reject(error);
    }
  });
};

export type Action =
  | ReturnType<typeof getLiveStats>
  | ReturnType<typeof fetchUserRequest>
  | ReturnType<typeof fetchUserSuccess>
  | ReturnType<typeof fetchUserFailure>;
