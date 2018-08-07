import * as React from 'react';
import Button from '@material-ui/core/Button';
import {
  Action,
  decrementCount,
  fetchCount,
  incrementCount
  } from '../actions/counter';
import { connect } from 'react-redux';
import { RootState } from '../reducers';
import { ThunkDispatch } from 'redux-thunk';

type Props = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps>;

const mapStateToProps = (state: RootState) => state.counter;

const mapDispatchToProps = (dispatch: ThunkDispatch<RootState, null, Action>) => ({
  fetchCount: () => dispatch(fetchCount()),
  incrementCount: () => dispatch(incrementCount()),
  decrementCount: () => dispatch(decrementCount())
});

class CounterContainer extends React.Component<Props> {
  constructor(props: Props) {
    super(props);
    props.fetchCount();
  }

  public increment = () => this.props.incrementCount();
  public decrement = () => this.props.decrementCount();

  public render() {
    const { count } = this.props;

    return (
      <React.Fragment>
        <p>{count}</p>
        <Button variant="contained" color="primary" onClick={this.increment} style={{ marginRight: '1em' }}>
          Increment
        </Button>
        <Button variant="contained" color="primary" onClick={this.decrement}>
          Decrement
        </Button>
      </React.Fragment>
    );
  }
}

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(CounterContainer);
