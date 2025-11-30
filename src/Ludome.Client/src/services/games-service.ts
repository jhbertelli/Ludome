import axios from 'services/axios'
import { GameOutput, GetPopularGamesInput } from './types'

const servicePath = import.meta.env.VITE_BACKEND_URL + 'api/Game/'

export class GamesService {
    static async getPopular(input: GetPopularGamesInput) {
        return await axios.get<GameOutput[], any, GetPopularGamesInput>(servicePath + 'GetPopular', {
            params: input,
        })
    }
}
