import * as React from 'react';
import Card from '@material-ui/core/Card';
import CardMedia from '@material-ui/core/CardMedia';
import {
  createStyles,
  Theme,
  withStyles,
  WithStyles
  } from '@material-ui/core/styles';

type Props = WithStyles<typeof styles>;

const styles = (theme: Theme) =>
  createStyles({
    card: {
      minWidth: 275,
      height: '100%'
    },
    media: {
      borderRadius: '4px',
      height: 0,
      paddingTop: '56.25%'
    }
  });

const MapCard: React.SFC<Props> = ({ classes }) => (
  <Card className={classes.card}>
    <CardMedia
      className={classes.media}
      image={`${process.env.PUBLIC_URL}/images/maps/coastline.png`}
      title="Coastline"
    />
  </Card>
);

export default withStyles(styles)(MapCard);
