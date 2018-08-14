import * as React from 'react';
import { createStyles, withStyles, WithStyles } from '@material-ui/core/styles';

type Props = WithStyles<typeof styles>;

const styles = () =>
  createStyles({
    map: {
      borderRadius: '4px',
      height: '100%',
      width: '100%'
    }
  });

const MapCard: React.SFC<Props> = ({ classes }) => (
  <img src={`${process.env.PUBLIC_URL}/assets/images/maps/coastline.png`} className={classes.map} />
);

export default withStyles(styles)(MapCard);
