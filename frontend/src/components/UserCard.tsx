import * as React from 'react';
import attacker from '../assets/operators/twitch.svg';
import Avatar from '@material-ui/core/Avatar';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import defender from '../assets/operators/lesion.svg';
import Divider from '@material-ui/core/Divider';
import Grid from '@material-ui/core/Grid';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import Typography from '@material-ui/core/Typography';
import {
  createStyles,
  Theme,
  withStyles,
  WithStyles
  } from '@material-ui/core/styles';
import { IUser } from '../interfaces/user';

type Props = WithStyles<typeof styles> & OwnProps;

type OwnProps = {
  user: IUser;
};

const styles = (theme: Theme) =>
  createStyles({
    card: {
      minWidth: 275,
      height: '100%'
    },
    icon: {
      borderRadius: 0
    }
  });

const UserCard: React.SFC<Props> = ({
  classes,
  user: {
    username,
    stats: { kills, deaths, killDeathRatio, wins, losses, winLossRatio }
  }
}) => (
  <Card className={classes.card}>
    <CardContent>
      <Typography gutterBottom variant="headline" component="h2">
        User Stats
      </Typography>
      <Divider />
      <Grid container spacing={24}>
        <Grid item xs={6}>
          <List component="nav">
            <ListItem>
              <ListItemText primary="Kills" secondary={kills} />
            </ListItem>
            <ListItem>
              <ListItemText primary="Deaths" secondary={deaths} />
            </ListItem>
            <ListItem>
              <ListItemText primary="K/D Ratio" secondary={killDeathRatio} />
            </ListItem>
            <ListItem>
              <Avatar alt="Twitch" src={attacker} className={classes.icon} />
              <ListItemText primary="Attacker" secondary="Twitch" />
            </ListItem>
          </List>
        </Grid>
        <Grid item xs={6}>
          <List component="nav">
            <ListItem>
              <ListItemText primary="Wins" secondary={wins} />
            </ListItem>
            <ListItem>
              <ListItemText primary="Losses" secondary={losses} />
            </ListItem>
            <ListItem>
              <ListItemText primary="W/L Ratio" secondary={winLossRatio} />
            </ListItem>
            <ListItem>
              <Avatar alt="Lesion" src={defender} className={classes.icon} />
              <ListItemText primary="Defender" secondary="Lesion" />
            </ListItem>
          </List>
        </Grid>
      </Grid>
    </CardContent>
  </Card>
);

export default withStyles(styles)(UserCard);
