import * as React from 'react';
import Loading from '../components/Loading';
import UserDashboard from '../components/UserDashboard';
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

    return user && !isFetching ? <UserDashboard user={user} /> : <Loading />;
  }
}

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(UserContainer);
