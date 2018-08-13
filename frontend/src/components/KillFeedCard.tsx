import * as React from 'react';
import Avatar from '@material-ui/core/Avatar';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
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
      width: '100%',
      position: 'relative',
      overflow: 'auto',
      maxHeight: 450,
      margin: '1em 0'
    },
    card: {
      minWidth: 275,
      height: '100%'
    },
    listItemText: {
      textAlign: 'right'
    }
  });

const killFeed = [
  { killer: 'Pigletoos', death: 'Gully-Foyle' },
  { killer: 'Pigletoos', death: 'JC' },
  { killer: 'Ollidar', death: 'Pigletoos' },
  { killer: 'Pigletoos', death: 'ITServices' },
  { killer: 'Refrigesaurus', death: 'Pigletoos' },
  { killer: 'Gully-Foyle', death: 'Pigletoos' },
  { killer: 'Pigletoos', death: 'Parnasas_' },
  { killer: 'Pigletoos', death: 'Gully-Foyle' },
  { killer: 'Pigletoos', death: 'JC' },
  { killer: 'Ollidar', death: 'Pigletoos' },
  { killer: 'Pigletoos', death: 'ITServices' },
  { killer: 'Refrigesaurus', death: 'Pigletoos' },
  { killer: 'Gully-Foyle', death: 'Pigletoos' },
  { killer: 'Pigletoos', death: 'Parnasas_' }
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
          <React.Fragment>
            <ListItem key={index}>
              <Grid container justify="center" alignItems="center">
                <Grid item xs={4}>
                  <ListItemText primary={killer} />
                </Grid>
                <Grid item xs={1}>
                  <Avatar>
                    <ForwardIcon />
                  </Avatar>
                </Grid>
                <Grid item xs={4}>
                  <ListItemText primary={death} className={classes.listItemText} />
                </Grid>
              </Grid>
            </ListItem>
            <Divider />
          </React.Fragment>
        ))}
      </List>
    </CardContent>
  </Card>
);

export default withStyles(styles)(KillFeedCard);
