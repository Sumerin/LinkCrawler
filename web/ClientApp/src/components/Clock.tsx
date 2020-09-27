import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as ClockStore from '../store/Clock'

type ClockProps = ClockStore.ClockState &
    typeof ClockStore.actionCreators &
    RouteComponentProps<[]>;


class Clock extends React.PureComponent<ClockProps>{
     
    public render() {
        let hours = ("0" + this.props.hours).slice(-2);
        let minutes = ("0" + this.props.minutes).slice(-2);
        let seconds = ("0" + this.props.seconds).slice(-2);
        return (
            <React.Fragment>
                <p style={{ fontSize: this.props.size + "px" }}>{hours}:{minutes}:{seconds}</p>
                <button type="button"
                    className="btn btn-primary btn-lg"
                    onClick={() => { this.props.increaseSize() }}>
                    Zoom In
                </button>
                <button type="button"
                    className="btn btn-primary btn-lg"
                    onClick={() => { this.props.decreaseSize() }}>
                    Zoom Out
                </button>
            </React.Fragment>
        );
    }

}

export default connect(
    (state: ApplicationState) => state.clock,
    ClockStore.actionCreators
)(Clock);