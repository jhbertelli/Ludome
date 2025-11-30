import { Star } from 'react-feather'
import { GameOutput } from 'services/types'

export const GameCard = ({ id, image, rating, reviewsCount, title }: GameOutput) => (
    <div key={`game_${id}`} className="flex flex-col gap-2">
        <div className="relative group overflow-hidden rounded-lg shadow-sm hover:shadow-md transition-shadow aspect-3/4">
            <img
                src={image}
                alt={title}
                className="w-full h-full object-cover transition-transform duration-300 group-hover:scale-105"
                onError={(e) => ((e.target as HTMLImageElement).src = 'https://placehold.co/300x400?text=No+Image')}
            />
            <div className="absolute inset-0 bg-linear-to-t from-black/80 via-transparent to-transparent opacity-90 flex items-end p-3">
                <span className="text-white text-sm font-bold leading-tight">{title}</span>
            </div>
        </div>
        <div className="flex items-center justify-center gap-1 text-sm">
            <Star className="fill-yellow-400 " color="transparent" />
            <span className="font-medium text-gray-900">{rating}</span>
            <span className="text-gray-500">({reviewsCount})</span>
        </div>
    </div>
)
