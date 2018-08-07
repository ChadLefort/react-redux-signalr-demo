import * as React from 'react';
import CssBaseline from '@material-ui/core/CssBaseline';
import grey from '@material-ui/core/colors/grey';
import { createMuiTheme, MuiThemeProvider } from '@material-ui/core/styles';

const theme = createMuiTheme({
  palette: {
    primary: {
      dark: grey[900],
      light: grey[300],
      main: grey[900]
    }
  },
  overrides: {
    MuiAppBar: {
      root: {
        marginBottom: '2em'
      }
    }
  }
});

const withRoot = (ComposedComponent: React.ComponentClass | React.SFC): React.SFC => ({ ...props }) => {
  return (
    <MuiThemeProvider theme={theme}>
      <CssBaseline />
      <ComposedComponent {...props} />
    </MuiThemeProvider>
  );
};

export default withRoot;
