const REGISTER = 'register'
const LOGIN = 'login'
const GAMES = 'games'

export const paths = {
    register: REGISTER,
    login: LOGIN,
    games: GAMES,
    game: GAMES + '/:id',
}

const pathTo = {
    register: `/${REGISTER}`,
    login: `/${LOGIN}`,
    games: `/${GAMES}`,
    game: (id: string) => `/${GAMES}/${id}`,
}

export { pathTo }
