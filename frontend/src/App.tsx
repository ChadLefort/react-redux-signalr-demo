import * as React from 'react';
import Layout from './components/Layout';
import store from './store';
import UserContainer from './containers/User';
import withRoot from './withRoot';
import { Provider } from 'react-redux';
import 'typeface-roboto';

const App: React.SFC = () => (
  <Provider store={store}>
    <Layout>
      <UserContainer />
    </Layout>
  </Provider>
);

export default withRoot(App);
