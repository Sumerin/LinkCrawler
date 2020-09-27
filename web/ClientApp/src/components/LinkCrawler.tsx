import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from "react-router";
import { ApplicationState } from '../store';
import * as LinkCrawlerStore from '../store/LinkCrawler'
import { Input } from 'reactstrap';


type LinkCrawlerProps= LinkCrawlerStore.LinkCrawlerState & 
typeof LinkCrawlerStore.actionCreators &
RouteComponentProps<[]>
interface IState{
    value:string;
}


class LinkCrawler extends React.PureComponent<LinkCrawlerProps, IState>{

    constructor(props:LinkCrawlerProps){
        super(props);
        this.state = {value:this.props.webLink ==null ? '' : this.props.webLink}
        this.handleForm = this.handleForm.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    public handleForm(event:React.FormEvent<HTMLFormElement>){
        this.props.requestLinkCrawl(this.state.value);
        event.preventDefault();
    }

    public handleChange(event:React.ChangeEvent<HTMLInputElement>){
        this.setState({value:event.target.value})
    }

    public render(){
        return(
            <React.Fragment>
                <form onSubmit={this.handleForm}>
                    <input type="text" value={this.state.value} onChange={this.handleChange}/>
                    <input type="submit" value="Crawl"/>
                </form>
            </React.Fragment>
        )
    }
}

export default connect(
    (state: ApplicationState) => state.linkCrawler,
    LinkCrawlerStore.actionCreators
)(LinkCrawler as any);

