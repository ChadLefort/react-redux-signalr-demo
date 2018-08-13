import * as React from 'react';
import attacker from '../assets/operators/twitch.svg';
import Avatar from '@material-ui/core/Avatar';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import defender from '../assets/operators/lesion.svg';
import Divider from '@material-ui/core/Divider';
import ForwardIcon from '@material-ui/icons/Forward';
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
import { Grid } from '@material-ui/core';

type Props = WithStyles<typeof styles>;

const styles = (theme: Theme) =>
  createStyles({
    root: {
      position: 'relative',
      overflow: 'auto',
      maxHeight: 600,
      margin: '1em 0'
    },
    card: {
      minWidth: 275,
      height: '100%'
    },
    icon: {
      borderRadius: 0
    },
    item: {
      paddingLeft: 0,
      paddingRight: 0
    }
  });

const killFeed = [
  { killer: 'chad', death: 'Gully-Foyle' },
  { killer: 'chad', death: 'JC' },
  { killer: 'Ollidar', death: 'chad' },
  { killer: 'chad', death: 'ITServices' },
  { killer: 'Refrige', death: 'chad' },
  { killer: 'Gully-Foyle', death: 'chad' },
  { killer: 'chad', death: 'Parnasas_' },
  { killer: 'chad', death: 'Gully-Foyle' },
  { killer: 'chad', death: 'JC' },
  { killer: 'Ollidar', death: 'chad' },
  { killer: 'chad', death: 'ITServices' },
  { killer: 'Refrige', death: 'chad' },
  { killer: 'Gully-Foyle', death: 'chad' },
  { killer: 'chad', death: 'Parnasas_' }
];

const KillFeedCard: React.SFC<Props> = ({ classes }) => (
  <Card className={classes.card}>
    <CardContent>
      <Typography gutterBottom variant="headline" component="h2">
        Kill Feed
      </Typography>
      <Divider />
      <List component="nav" className={classes.root}>
        {killFeed.map(({ killer, death }, index) => (
          <React.Fragment key={index}>
            <Grid container justify="center" alignItems="center">
              <Grid item md={5}>
                <ListItem disableGutters>
                  <Avatar alt="Twitch" src={attacker} className={classes.icon} />
                  <ListItemText primary={killer} />
                </ListItem>
              </Grid>
              <Grid item md={2}>
                <Avatar>
                  <ForwardIcon />
                </Avatar>
              </Grid>
              <Grid item md={5}>
                <ListItem disableGutters>
                  <Avatar alt="Lesion" src={defender} className={classes.icon} />
                  <ListItemText primary={death} />
                </ListItem>
              </Grid>
            </Grid>
            <Divider />
          </React.Fragment>
        ))}
      </List>
    </CardContent>
  </Card>
);

export default withStyles(styles)(KillFeedCard);
