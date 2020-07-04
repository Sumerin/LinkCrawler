import { Action, Reducer } from 'redux';

const defaultSize: number = 12;
const changeThreshold: number = 3
const maxSize: number = 60
const minSize: number = 8

//State
export interface ClockState {
    hours: number,
    minutes: number,
    seconds: number,
    size: number;
}

const defaultClockState:ClockState = {
    hours: (new Date()).getHours(),
    minutes: (new Date()).getMinutes(),
    seconds: (new Date()).getSeconds(),
    size: defaultSize
}

//Actions
export const TickSecondsType = 'TICK_SECONDS'
export const IncreaseSizeType = 'INCREASE_SIZE'
export const DecreaseSizeType = 'DECREASE_SIZE'

export interface TickSecondsAction { type: typeof TickSecondsType }
export interface IncreaseSizeAction { type: typeof IncreaseSizeType }
export interface DecreaseSizeAction { type: typeof DecreaseSizeType }

export type KnownAction = TickSecondsAction | IncreaseSizeAction | DecreaseSizeAction

//Action creators

export const actionCreators = {
    tick: () => ({ type: TickSecondsType } as TickSecondsAction),
    increaseSize: () => ({ type: IncreaseSizeType } as IncreaseSizeAction),
    decreaseSize: () => ({ type: DecreaseSizeType } as DecreaseSizeAction)
};

export const reducer: Reducer<ClockState> = (state: ClockState = defaultClockState, incomingAction: Action)
    : ClockState => {

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case TickSecondsType:
            let seconds = (state.seconds + 1) % 60;
            let minutes = state.minutes;
            let hours = state.hours;
            if (seconds === 0) {
                minutes = (minutes + 1) % 60;
                if (minutes === 0) {
                    hours = (hours + 1) % 24;
                }
            }
            return {
                hours: hours,
                minutes: minutes,
                seconds: seconds,
                size: state.size
            }

        case IncreaseSizeType:
            return {
                hours: state.hours,
                minutes: state.minutes,
                seconds: state.seconds,
                size: (state.size + changeThreshold) <= maxSize ? (state.size + changeThreshold) : state.size
            }

        case DecreaseSizeType:
            return {
                hours: state.hours,
                minutes: state.minutes,
                seconds: state.seconds,
                size: (state.size - changeThreshold) >= minSize ? (state.size - changeThreshold) : state.size
            }
        default:
            return state;
    }
}
