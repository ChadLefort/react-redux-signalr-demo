import { combineReducers } from 'redux';
import { reducer as user, State as UserState } from './user';

export type RootState = {
  user: UserState;
};

export default combineReducers<RootState>({
  user
});
