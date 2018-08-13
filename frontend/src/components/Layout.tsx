import * as React from 'react';
import AppBar from '@material-ui/core/AppBar';
import Grid from '@material-ui/core/Grid';
import logo from '../assets/logo.svg';
import Toolbar from '@material-ui/core/Toolbar';
import {
  createStyles,
  Theme,
  withStyles,
  WithStyles
  } from '@material-ui/core/styles';

type Props = WithStyles<typeof styles>;

const styles = (theme: Theme) =>
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
        <img src={logo} className={classes.logo} />
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
