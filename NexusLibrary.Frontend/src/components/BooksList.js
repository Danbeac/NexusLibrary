import imageBook from '../images/book.jpg';


function BooksList(props){
    const books = props.books;
    const miniLibrary = books.slice(books.length-9);

    const divStyle = {
        width: '18rem'
    }

    return(
        <div className="container d-flex flex-wrap">
            {
                miniLibrary.map(book => {
                    return(
                        <div className="card m-4" style={divStyle}>
                            <img src={imageBook} className="card-img-top" alt="Book"/>
                            <div className="card-body">
                                <h5 className="card-title">{book.title}</h5>
                                <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                                <a href="#" className="btn btn-primary">Details</a>
                            </div>  
                        </div>
                    )
                })
            }
        </div>
    )


}

export default BooksList;