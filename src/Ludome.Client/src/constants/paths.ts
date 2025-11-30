const REGISTER = 'register'
const LOGIN = 'login'
const GAMES = 'games'

export const paths = {
    register: REGISTER,
    login: LOGIN,
    games: GAMES,
}

const pathTo = {
    register: `/${REGISTER}`,
    login: `/${LOGIN}`,
    games: `/${GAMES}`,
}

export { pathTo }
