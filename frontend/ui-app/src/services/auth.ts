export const setAuth = (data: any) => {
  localStorage.setItem("user", JSON.stringify(data));
};

export const getAuth = () => {
  const data = localStorage.getItem("user");
  return data ? JSON.parse(data) : null;
};

export const isLoggedIn = () => {
  return getAuth() !== null;
};

export const logout = () => {
  localStorage.removeItem("user");
};