import * as React from 'react';
import Loading from '../components/Loading';
import UserDashboard from '../components/UserDashboard';
import { Action, fetchUser, startFetchMatch } from '../actions/user';
import { connect } from 'react-redux';
import { fetchKillFeed } from '../actions/killFeed';
import { fetchOperatorsIfNeeded } from '../actions/operators';
import { RootState } from '../reducers';
import { ThunkDispatch } from 'redux-thunk';

type Props = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps>;

const mapStateToProps = ({
  user: { user, isFetching: isFetchingUser },
  killFeed: { killFeed, isFetching: isFetchingKillFeed },
  operators: { operators, isFetching: isFetchingOperators }
}: RootState) => ({
  user,
  killFeed,
  operators,
  isFetching: isFetchingUser || isFetchingKillFeed || isFetchingOperators
});

const mapDispatchToProps = (dispatch: ThunkDispatch<RootState, null, Action>) => ({
  fetchUser: (userId: number) => dispatch(fetchUser(userId)),
  fetchKillFeed: (killFeedId: number) => dispatch(fetchKillFeed(killFeedId)),
  fetchOperatorsIfNeeded: () => dispatch(fetchOperatorsIfNeeded()),
  startFetchMatch: (userId: number, matchId: number) => dispatch(startFetchMatch(userId, matchId))
});

class UserContainer extends React.Component<Props> {
  constructor(props: Props) {
    super(props);
    props.fetchOperatorsIfNeeded();
    props.fetchUser(1);
    props.fetchKillFeed(1);
    props.startFetchMatch(1, 1);
  }

  public render() {
    const { user, killFeed, operators, isFetching } = this.props;

    return user && killFeed && operators && !isFetching ? (
      <UserDashboard user={user} killFeed={killFeed} operators={operators} />
    ) : (
      <Loading />
    );
  }
}

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(UserContainer);
