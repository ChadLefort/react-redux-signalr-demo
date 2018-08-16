import * as React from 'react';
import Avatar from '@material-ui/core/Avatar';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import Divider from '@material-ui/core/Divider';
import Grid from '@material-ui/core/Grid';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import Typography from '@material-ui/core/Typography';
import { createStyles, withStyles, WithStyles } from '@material-ui/core/styles';
import { IOperator } from '../interfaces/operator';
import { IUser } from '../interfaces/user';

type Props = WithStyles<typeof styles> & OwnProps;

type OwnProps = {
  user: IUser;
  operators: IOperator[];
};

const styles = () =>
  createStyles({
    card: {
      height: '100%'
    },
    icon: {
      borderRadius: 0
    }
  });

const UserCard: React.SFC<Props> = ({
  classes,
  operators,
  user: {
    stats: { kills, deaths, killDeathRatio, wins, losses, winLossRatio, topAttacker, topDefender }
  }
}) => {
  const { icon: topAttackerIcon } = operators.find(({ name }) => name === topAttacker)!;
  const { icon: topDefenderIcon } = operators.find(({ name }) => name === topDefender)!;

  return (
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
                <Avatar
                  alt={topAttacker}
                  src={`${process.env.PUBLIC_URL}/assets/operators/${topAttackerIcon}`}
                  className={classes.icon}
                />
                <ListItemText primary="Attacker" secondary={topAttacker} />
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
                <Avatar
                  alt={topDefender}
                  src={`${process.env.PUBLIC_URL}/assets/operators/${topDefenderIcon}`}
                  className={classes.icon}
                />
                <ListItemText primary="Defender" secondary={topDefender} />
              </ListItem>
            </List>
          </Grid>
        </Grid>
      </CardContent>
    </Card>
  );
};

export default withStyles(styles)(UserCard);
