import axios from 'services/axios'
import { DeleteRatingInput, GameDetailOutput, GameOutput, GetPopularGamesInput, RatingOutput } from './types'
import { RatingInput } from './types/rating-input'

const servicePath = import.meta.env.VITE_BACKEND_URL + 'api/Game/'

export class GamesService {
    static async getPopular(input: GetPopularGamesInput) {
        return await axios.get<GameOutput[], any, GetPopularGamesInput>(`${servicePath}GetPopular`, {
            params: input,
        })
    }

    static async getGameDetails(id: string) {
        return await axios.get<GameDetailOutput>(`${servicePath}GetGameDetails/${id}`)
    }

    static async getGameRatings(id: string) {
        return await axios.get<RatingOutput[]>(`${servicePath}GetGameRatings/${id}`)
    }

    static async rateGame(input: RatingInput) {
        return await axios.post<void>(`${servicePath}RateGame`, input)
    }

    static async deleteRating(input: DeleteRatingInput) {
        return await axios.delete<void>(`${servicePath}DeleteRating`, { data: input })
    }
}
