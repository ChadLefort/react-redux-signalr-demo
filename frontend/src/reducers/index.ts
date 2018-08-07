import { combineReducers } from 'redux';
import { reducer as counter, State as CounterState } from './counter';

export type RootState = {
  counter: CounterState;
};

export default combineReducers<RootState>({
  counter
});
