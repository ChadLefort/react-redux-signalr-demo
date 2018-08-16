import * as React from 'react';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import Divider from '@material-ui/core/Divider';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import { createStyles, withStyles, WithStyles } from '@material-ui/core/styles';
import { IUser } from '../interfaces/user';
import {
  VictoryBar,
  VictoryChart,
  VictoryTheme,
  VictoryTooltip
  } from 'victory';

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

const KillDeathCard: React.SFC<Props> = ({
  classes,
  user: {
    stats: { kills, deaths }
  }
}) => (
  <Card className={classes.card}>
    <CardContent>
      <Typography gutterBottom variant="headline" component="h2">
        Kill &amp; Deaths
      </Typography>
      <Divider />
      <Grid container>
        <Grid item xs={12}>
          <VictoryChart theme={VictoryTheme.material} domainPadding={{ x: 100, y: 25 }} height={250}>
            <VictoryBar
              style={{ data: { fill: '#212121' } }}
              animate={{ duration: 2000, easing: 'bounce', onLoad: { duration: 1000 } }}
              categories={{ x: ['Kills', 'Deaths'], y: [] }}
              data={[{ x: 'Kills', y: kills }, { x: 'Deaths', y: deaths }]}
              labels={[`${kills}`, `${deaths}`]}
              labelComponent={<VictoryTooltip />}
            />
          </VictoryChart>
        </Grid>
      </Grid>
    </CardContent>
  </Card>
);

export default withStyles(styles)(KillDeathCard);
