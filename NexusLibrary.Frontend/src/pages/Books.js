import React from 'react';
import api from '../api';
import imageBook from '../images/book.jpg';
import BooksList from '../components/BooksList';

class MainComponent extends React.Component {
    state = {
        data : undefined
    }

    componentWillMount(){
        this.fetchData();
    }

    fetchData = async () => {
        try{
            const res = await api.books.list();
            this.setState({data : res.data});
            console.log(this.state.data);
        }catch(error){
            console.log(error);
        }
    }

    render(){
        if(!this.state.data){
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