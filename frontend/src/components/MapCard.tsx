import * as React from 'react';
import {
  createStyles,
  Theme,
  withStyles,
  WithStyles
  } from '@material-ui/core/styles';

type Props = WithStyles<typeof styles>;

const styles = (theme: Theme) =>
  createStyles({
    map: {
      borderRadius: '4px',
      height: '100%',
      width: '100%'
    }
  });

const MapCard: React.SFC<Props> = ({ classes }) => (
  <img src={`${process.env.PUBLIC_URL}/images/maps/coastline.png`} className={classes.map} />
);

export default withStyles(styles)(MapCard);
