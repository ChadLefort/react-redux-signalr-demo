import * as React from 'react';
import Grid from '@material-ui/core/Grid';
import KillDeathCard from './KillDeathCard';
import KillFeedCard from './KillFeedCard';
import MapCard from './MapCard';
import rank from '../assets/ranks/gold-one.svg';
import UserCard from './UserCard';
import WinLossCard from './WinLossCard';
import {
  createStyles,
  Theme,
  withStyles,
  WithStyles
  } from '@material-ui/core/styles';
import { Divider, Typography } from '@material-ui/core';
import { IUser } from '../interfaces/user';

type Props = WithStyles<typeof styles> & OwnProps;

type OwnProps = {
  user: IUser;
};

const styles = (theme: Theme) =>
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

const UserDashboard: React.SFC<Props> = ({ user, classes }) => (
  <React.Fragment>
    <Grid container className={classes.root} justify="center" spacing={16}>
      <Grid item xs={9}>
        <Typography variant="display1" gutterBottom className={classes.display1}>
          <img src={rank} className={classes.rank} />
          {user.username}
        </Typography>
        <Divider />
      </Grid>
    </Grid>
    <Grid container className={classes.root} justify="center" spacing={16}>
      <Grid item xs={12} md={3}>
        <UserCard user={user} />
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
        <KillFeedCard />
      </Grid>
      <Grid item xs={12} md={6}>
        <MapCard />
      </Grid>
    </Grid>
  </React.Fragment>
);

export default withStyles(styles)(UserDashboard);