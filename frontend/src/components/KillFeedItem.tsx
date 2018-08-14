import * as React from 'react';
import Avatar from '@material-ui/core/Avatar';
import Divider from '@material-ui/core/Divider';
import ForwardIcon from '@material-ui/icons/Forward';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import { createStyles, withStyles, WithStyles } from '@material-ui/core/styles';
import { Grid } from '@material-ui/core';
import { IDeath, IKill } from '../interfaces/killFeed';
import { IOperator } from '../interfaces/operator';

type Props = WithStyles<typeof styles> & OwnProps;

type OwnProps = {
  kill: IKill;
  death: IDeath;
  operators: IOperator[];
};

const styles = () =>
  createStyles({
    icon: {
      borderRadius: 0
    }
  });

const KillFeedItem: React.SFC<Props> = ({ kill, death, operators, classes }) => {
  const killOperator = operators.find(({ name }) => name === kill.operator)!;
  const deathOperator = operators.find(({ name }) => name === death.operator)!;

  return (
    <React.Fragment>
      <Grid container justify="center" alignItems="center">
        <Grid item md={5}>
          <ListItem disableGutters>
            <Avatar
              alt={killOperator.name}
              src={`${process.env.PUBLIC_URL}/assets/operators/${killOperator.icon}`}
              className={classes.icon}
            />
            <ListItemText primary={kill.username} />
          </ListItem>
        </Grid>
        <Grid item md={2}>
          <Avatar>
            <ForwardIcon />
          </Avatar>
        </Grid>
        <Grid item md={5}>
          <ListItem disableGutters>
            <Avatar
              alt={deathOperator.name}
              src={`${process.env.PUBLIC_URL}/assets/operators/${deathOperator.icon}`}
              className={classes.icon}
            />
            <ListItemText primary={death.username} />
          </ListItem>
        </Grid>
      </Grid>
      <Divider />
    </React.Fragment>
  );
};

export default withStyles(styles)(KillFeedItem);
