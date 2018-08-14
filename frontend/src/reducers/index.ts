import { combineReducers } from 'redux';
import { reducer as killFeed, State as KillFeedState } from './killFeed';
import { reducer as operators, State as OperatorsState } from './operators';
import { reducer as user, State as UserState } from './user';

export type RootState = {
  killFeed: KillFeedState;
  operators: OperatorsState;
  user: UserState;
};

export default combineReducers<RootState>({
  killFeed,
  operators,
  user
});
