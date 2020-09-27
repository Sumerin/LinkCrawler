import { Action, Reducer } from 'redux';
import { AppThunkAction } from './';


//CONTROLERS URI
const controllerUri = 'linkCrawlerApi';

//STATE

export interface LinkCrawlerState{
    pages: Page[];
    isLoading:boolean;
    webLink?:string;
}

export interface Page{
    domains: string[];
}


const defaultState:LinkCrawlerState ={
    pages:[],
    isLoading: true,
} 


//ACTIONS
export const RequestLinkCrawlerType = 'REQUEST_LINK_CRAWLER' ;
export const ResponseLinkCrawlerType = 'RESPONSE_LINK_CRAWLER' ;


interface RequestLinkCrawler{
    type:typeof RequestLinkCrawlerType;
    webLink:string;
}
interface ResponseLinkCrawler{
    type:typeof ResponseLinkCrawlerType;
    webLink:string;
    pages:Page[];
}


type KnownAction = RequestLinkCrawler| ResponseLinkCrawler;

export const actionCreators={
    requestLinkCrawl: (webLink:string):AppThunkAction<KnownAction>=>(dispatch,getState) =>{
        const appState = getState();
        if(appState && appState.linkCrawler && webLink !== appState.linkCrawler.webLink)
        {
            fetch(controllerUri)
            .then(response => response.json() as Promise<Page[]>)
            .then(data=>{
                dispatch({
                    type: ResponseLinkCrawlerType,
                    webLink:webLink,
                    pages:data})
            })
        }
    }

}

//REDUCER

export const reducer:Reducer<LinkCrawlerState> = (state:LinkCrawlerState = defaultState, incomingAction:Action) : LinkCrawlerState=>{
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case RequestLinkCrawlerType:
            return{
                pages:state.pages,
                webLink: action.webLink,
                isLoading: true
            }
            break;
            case ResponseLinkCrawlerType:
                if(action.webLink === state.webLink){
                    return {
                        pages:action.pages,
                        webLink: action.webLink,
                        isLoading: false
                    }
                }
                break;
    }
    return state;
}
