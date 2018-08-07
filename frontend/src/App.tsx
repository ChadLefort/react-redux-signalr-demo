import * as React from 'react';
import CounterContainer from './containers/Counter';
import Layout from './components/Layout';
import store from './store';
import withRoot from './withRoot';
import { Provider } from 'react-redux';
import './App.css';

const App: React.SFC = () => (
  <Provider store={store}>
    <Layout>
      <CounterContainer />
    </Layout>
  </Provider>
);

export default withRoot(App);
