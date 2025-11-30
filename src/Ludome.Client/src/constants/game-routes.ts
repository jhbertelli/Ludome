import GamesPage from 'pages/GamesPage'
import { RouteObject } from 'react-router-dom'
import { paths } from './paths'

export const gameRoutes: RouteObject[] = [{ path: paths.games, Component: GamesPage }]
