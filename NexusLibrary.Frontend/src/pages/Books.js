import React from 'react';
import api from '../api';
import BooksList from '../components/BooksList';
import PageError from '../components/PageError';

class MainComponent extends React.Component {
    state = {
        data : undefined,
        loading: true,
        error: null
    }

    componentWillMount(){
        this.fetchData();
    }

    fetchData = async () => {
        this.setState({loading: true, error: null});

        try{
            const res = await api.books.list();
            this.setState({loading: false, data : res.data});
        }catch(error){
            this.setState({loading: false, error: error});
        }
    }

    render(){

        if(this.state.error){
            return <PageError error={this.state.error}/>
        }

        if(this.state.loading || !this.state.data){
            return(<p>Loading ...</p>)
        }

        return (
            <React.Fragment>
            <h1>Books</h1>

            <BooksList books={this.state.data}/>
            </React.Fragment>
        )
    }
}

export default MainComponent;