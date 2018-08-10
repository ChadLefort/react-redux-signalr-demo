import axios, { AxiosError } from 'axios';
import { ActionType } from '../reducers/user';
import { IUser } from '../interfaces/user';
import { RootState } from '../reducers';
import { ThunkAction } from 'redux-thunk';
// import hub from '../hub';
// import { Store } from 'redux';

export const increment = (payload: number) => ({
  type: ActionType.INCREMENT_USER as typeof ActionType.INCREMENT_USER,
  payload
});

export const decrement = (payload: number) => ({
  type: ActionType.DECREMENT_USER as typeof ActionType.DECREMENT_USER,
  payload
});

// export const incrementUser = (): ThunkAction<void, RootState, null, Action> => () =>
//   hub.invoke(HubMethod.IncrementUserer);

// export const decrementUser = (): ThunkAction<void, RootState, null, Action> => () =>
//   hub.invoke(HubMethod.DecrementUserer);

// export const signalRRegisterCommands = async (store: Store, cb: () => void) => {
//   hub.on(HubMethod.IncrementUserer, ({ user }) => store.dispatch(increment(user)));
//   hub.on(HubMethod.DecrementUserer, ({ user }) => store.dispatch(decrement(user)));
//   await hub.start();
//   cb();
// };

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
  | ReturnType<typeof increment>
  | ReturnType<typeof decrement>
  | ReturnType<typeof fetchUserRequest>
  | ReturnType<typeof fetchUserSuccess>
  | ReturnType<typeof fetchUserFailure>;
