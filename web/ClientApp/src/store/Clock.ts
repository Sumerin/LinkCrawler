import { Action, Reducer } from 'redux';

const defaultSize = 12;

//State
export interface ClockState {
    hours: number,
    minutes: number,
    seconds: number,
    size: number;
}

//Actions
export type TickSecondsType = 'TICK_SECONDS'
export type IncreaseSizeType = 'INCREASE_SIZE'
export type DecreaseSizeType = 'INCREASE_SIZE'

export interface TickSecondsAction { type: TickSecondsType }
export interface IncreaseSizeAction { type: IncreaseSizeType }
export interface DecreaseSizeAction { type: DecreaseSizeType }

export type KnownAction = TickSecondsAction | IncreaseSizeAction | DecreaseSizeAction

//Action creators

export const actionCreators = {
    tick: () => ({ type: TickSecondsType } as TickSecondsAction),
    increaseSize: () => ({ type: IncreaseSizeType } as IncreaseSizeAction),
    decreaseSize: () => ({ type: DecreaseSizeType } as DecreaseSizeAction)
};

export const reducer: Reducer<ClockState> = (state: ClockState | undefined, incomingAction: Action)
    : ClockState => {
    if (state === undefined) {
        return {
            hours: (new Date()).getHours(),
            minutes: (new Date()).getMinutes(),
            seconds: (new Date()).getSeconds(),
            size: defaultSize
        }
    }
    
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case TickSecondsType:
            let seconds = state.seconds + 1 % 60;
            let minutes = state.minutes;
            let hours = state.hours;
            if( seconds === 0) 
            { minutes = minutes + 1 % 60}
            
            break;
    
        default:
            break;
    }
}
}

