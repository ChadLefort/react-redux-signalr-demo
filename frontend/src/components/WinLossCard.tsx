import * as React from 'react';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import Divider from '@material-ui/core/Divider';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import { createStyles, withStyles, WithStyles } from '@material-ui/core/styles';
import { IUser } from '../interfaces/user';
import { VictoryPie, VictoryTheme } from 'victory';

type Props = WithStyles<typeof styles> & OwnProps;

type OwnProps = {
  user: IUser;
};

const styles = () =>
  createStyles({
    card: {
      height: '100%'
    }
  });

const WinLossCard: React.SFC<Props> = ({
  classes,
  user: {
    stats: { wins, losses }
  }
}) => (
  <Card className={classes.card}>
    <CardContent>
      <Typography gutterBottom variant="headline" component="h2">
        Wins &amp; Losses
      </Typography>
      <Divider />
      <Grid container>
        <Grid item xs={12}>
          <VictoryPie
            theme={VictoryTheme.material}
            colorScale={['#212121', '#424242']}
            height={250}
            data={[{ x: 'Wins', y: wins }, { x: 'Losses', y: losses }]}
          />
        </Grid>
      </Grid>
    </CardContent>
  </Card>
);

export default withStyles(styles)(WinLossCard);
