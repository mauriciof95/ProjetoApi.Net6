function SetLocalStorageToken(token) {
    localStorage.setItem('Token', token);
}

function GetLocalStorageToken() {
    return localStorage.getItem('Token');
}

function ClearLocalStorage() {
    localStorage.clear();
}
