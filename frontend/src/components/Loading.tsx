import * as React from 'react';
import CircularProgress from '@material-ui/core/CircularProgress';
import { createStyles, withStyles, WithStyles } from '@material-ui/core/styles';

type Props = WithStyles<typeof styles>;

const styles = () =>
  createStyles({
    root: {
      display: 'flex',
      alignItems: 'center',
      justifyContent: 'center',
      height: '80vh'
    }
  });

const Loading: React.SFC<Props> = ({ classes }) => (
  <div className={classes.root}>
    <CircularProgress />
  </div>
);

export default withStyles(styles)(Loading);
