import * as React from 'react';
import AppBar from '@material-ui/core/AppBar';
import Grid from '@material-ui/core/Grid';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import {
  createStyles,
  Theme,
  withStyles,
  WithStyles
  } from '@material-ui/core/styles';
// import Paper from '@material-ui/core/Paper';

type Props = WithStyles<typeof styles>;

const styles = (theme: Theme) =>
  createStyles({
    root: {
      flexGrow: 1
    },
    paper: {
      padding: theme.spacing.unit * 2,
      textAlign: 'center',
      color: theme.palette.text.secondary
    }
  });

const Layout: React.SFC<Props> = ({ children, classes }) => (
  <React.Fragment>
    <AppBar position="static">
      <Toolbar>
        <Typography variant="title" color="inherit">
          R6 Stats
        </Typography>
      </Toolbar>
    </AppBar>
    <div className={classes.root}>
      <Grid container justify="center">
        <Grid item xs={3}>
          {children}
        </Grid>
      </Grid>
    </div>
  </React.Fragment>
);

export default withStyles(styles)(Layout);
