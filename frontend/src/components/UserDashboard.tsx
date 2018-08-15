import * as React from 'react';
import Grid from '@material-ui/core/Grid';
import KillDeathCard from './KillDeathCard';
import KillFeedCard from './KillFeedCard';
import MapCard from './MapCard';
import UserCard from './UserCard';
import WinLossCard from './WinLossCard';
import { createStyles, withStyles, WithStyles } from '@material-ui/core/styles';
import { Divider, Typography } from '@material-ui/core';
import { IKillFeed } from '../interfaces/killFeed';
import { IOperator } from '../interfaces/operator';
import { IUser } from '../interfaces/user';

type Props = WithStyles<typeof styles> & OwnProps;

type OwnProps = {
  user: IUser;
  killFeed: IKillFeed;
  operators: IOperator[];
};

const styles = () =>
  createStyles({
    root: {
      width: '100%'
    },
    display1: {
      display: 'flex',
      alignItems: 'center'
    },
    rank: {
      height: '100px'
    }
  });

const UserDashboard: React.SFC<Props> = ({ user, killFeed, operators, classes }) => (
  <React.Fragment>
    <Grid container className={classes.root} justify="center" spacing={16}>
      <Grid item xs={9}>
        <Typography variant="display1" gutterBottom className={classes.display1}>
          <img src={`${process.env.PUBLIC_URL}/assets/ranks/gold-one.svg`} className={classes.rank} />
          {user.username}
        </Typography>
        <Divider />
      </Grid>
    </Grid>
    <Grid container className={classes.root} justify="center" spacing={16}>
      <Grid item xs={12} md={3}>
        <UserCard user={user} operators={operators} />
      </Grid>
      <Grid item xs={12} md={3}>
        <KillDeathCard user={user} />
      </Grid>
      <Grid item xs={12} md={3}>
        <WinLossCard user={user} />
      </Grid>
    </Grid>
    <Grid container className={classes.root} justify="center" spacing={16}>
      <Grid item xs={12} md={3}>
        <KillFeedCard killFeed={killFeed} operators={operators} />
      </Grid>
      <Grid item xs={12} md={4}>
        <MapCard killFeed={killFeed} />
      </Grid>
    </Grid>
  </React.Fragment>
);

export default withStyles(styles)(UserDashboard);
