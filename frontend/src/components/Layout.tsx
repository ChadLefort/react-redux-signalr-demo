import * as React from 'react';
import AppBar from '@material-ui/core/AppBar';
import Grid from '@material-ui/core/Grid';
import Toolbar from '@material-ui/core/Toolbar';
import { createStyles, withStyles, WithStyles } from '@material-ui/core/styles';

type Props = WithStyles<typeof styles>;

const styles = () =>
  createStyles({
    root: {
      flexGrow: 1
    },
    logo: {
      height: '40px'
    }
  });

const Layout: React.SFC<Props> = ({ children, classes }) => (
  <React.Fragment>
    <AppBar position="static">
      <Toolbar>
        <img src={`${process.env.PUBLIC_URL}/assets/logo.svg`} className={classes.logo} />
      </Toolbar>
    </AppBar>
    <div className={classes.root}>
      <Grid container justify="center">
        <Grid item xs>
          {children}
        </Grid>
      </Grid>
    </div>
  </React.Fragment>
);

export default withStyles(styles)(Layout);
