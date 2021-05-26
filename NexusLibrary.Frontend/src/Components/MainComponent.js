import React from 'react';
import api from '../api';

class MainComponent extends React.Component {
    state = {
        data : undefined
    }

    componentDidMount(){
        this.fetchData();
    }

    fetchData = async () => {
        try{
            const res = await api.books.list();
            this.setState({data : res.data});
            console.log(res.data);
        }catch(error){
            console.log(error);
        }
    }

    render(){
        return <p>Hola Mundo</p>
    }
}

export default MainComponent;