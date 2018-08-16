import * as React from 'react';
import AppBar from '@material-ui/core/AppBar';
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
    {children}
  </React.Fragment>
);

export default withStyles(styles)(Layout);
