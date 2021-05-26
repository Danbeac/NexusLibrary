const BASE_URL = "https://localhost:44383/api/";

async function callApi(endpoint, options = {}) {
  options.headers = {
    "Content-Type": "application/json",
    Accept: "application/json",
  };

  const url = BASE_URL + endpoint;
  const response = await fetch(url, options);
  const data = await response.json();

  return data;
}

const api = {
  books: {
    list() {
      return callApi("Book");
    },
  },
};

export default api;
