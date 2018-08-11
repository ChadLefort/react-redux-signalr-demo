import * as React from 'react';
import CircularProgress from '@material-ui/core/CircularProgress';
import UserCard from '../components/UserCard';
import { Action, fetchUser, startFetchMatch } from '../actions/user';
import { connect } from 'react-redux';
import { RootState } from '../reducers';
import { ThunkDispatch } from 'redux-thunk';

type Props = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps>;

const mapStateToProps = (state: RootState) => state.user;

const mapDispatchToProps = (dispatch: ThunkDispatch<RootState, null, Action>) => ({
  fetchUser: (userId: number) => dispatch(fetchUser(userId)),
  startFetchMatch: (userId: number) => dispatch(startFetchMatch(userId))
});

class UserContainer extends React.Component<Props> {
  constructor(props: Props) {
    super(props);
    props.fetchUser(1);
    props.startFetchMatch(1);
  }

  public render() {
    const { user, isFetching } = this.props;

    return user && !isFetching ? <UserCard user={user} /> : <CircularProgress />;
  }
}

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(UserContainer);
