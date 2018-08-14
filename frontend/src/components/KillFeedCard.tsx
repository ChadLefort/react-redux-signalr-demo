import * as React from 'react';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import Divider from '@material-ui/core/Divider';
import KillFeedItem from './KillFeedItem';
import List from '@material-ui/core/List';
import Typography from '@material-ui/core/Typography';
import { createStyles, withStyles, WithStyles } from '@material-ui/core/styles';
import { IKillFeed } from '../interfaces/killFeed';
import { IOperator } from '../interfaces/operator';

type Props = WithStyles<typeof styles> & OwnProps;

type OwnProps = {
  killFeed: IKillFeed;
  operators: IOperator[];
};

const styles = () =>
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
    item: {
      paddingLeft: 0,
      paddingRight: 0
    }
  });

class KillFeedCard extends React.Component<Props> {
  public render() {
    const {
      classes,
      killFeed: { killFeedItems },
      operators
    } = this.props;

    return (
      <Card className={classes.card}>
        <CardContent>
          <Typography gutterBottom variant="headline" component="h2">
            Kill Feed
          </Typography>
          <Divider />
          <List component="nav" className={classes.root}>
            {killFeedItems.map(({ killFeedItemId, kill, death }) => (
              <KillFeedItem key={killFeedItemId} kill={kill} death={death} operators={operators} />
            ))}
          </List>
        </CardContent>
      </Card>
    );
  }
}

export default withStyles(styles)(KillFeedCard);
