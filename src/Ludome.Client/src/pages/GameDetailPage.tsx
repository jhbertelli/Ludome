import { Button, Loader, Rating, Textarea } from '@mantine/core'
import { Header } from 'components/Header'
import { pathTo } from 'constants/paths'
import { useDeleteRating } from 'hooks/use-delete-rating'
import { useGetGameDetails } from 'hooks/use-get-game-details'
import { useGetGameRatings } from 'hooks/use-get-game-ratings'
import { useRateGame } from 'hooks/use-rate-game'
import { useMemo } from 'react'
import { ArrowLeft, Star, Trash2, User } from 'react-feather'
import { SubmitHandler, useForm } from 'react-hook-form'
import { useNavigate, useParams } from 'react-router-dom'
import { RatingsSchema } from 'schemas/rating'

export default function GameDetails() {
    const { id: gameId } = useParams() as { id: string }
    const navigate = useNavigate()
    const { data: game } = useGetGameDetails(gameId)
    const { data: ratings, isLoading: isRatingsLoading } = useGetGameRatings(gameId)
    const rateGame = useRateGame()
    const deleteRating = useDeleteRating()

    const { register, handleSubmit, setValue } = useForm<RatingsSchema>({
        defaultValues: { score: 0, comment: '' },
    })

    const userReview = useMemo(() => ratings?.find((r) => r.isMine), [ratings])

    const onSubmit: SubmitHandler<RatingsSchema> = async (data) => await rateGame.mutateAsync({ gameId, ...data })

    return (
        <div className="min-h-screen font-sans">
            <Header />
            <div className="container mx-auto px-6 pt-6">
                <button
                    onClick={() => navigate(pathTo.games)}
                    className="mb-6 flex items-center text-gray-600 hover:text-purple-700 transition-colors font-medium cursor-pointer"
                >
                    <ArrowLeft size={20} className="mr-2" />
                    Voltar para a lista
                </button>

                <div className="flex flex-col lg:flex-row gap-8 items-start">
                    <div className="w-full lg:w-[400px] shrink-0">
                        <div className="bg-white rounded-lg border border-gray-200 shadow-sm p-5 flex flex-col">
                            {game && (
                                <>
                                    <div className="flex justify-between items-start mb-4">
                                        <h2 className="text-xl font-bold text-gray-900 leading-tight">{game.title}</h2>
                                        <div className="flex items-center gap-1 shrink-0">
                                            <Star className="fill-yellow-400 text-yellow-400 w-5 h-5" />
                                            <span className="font-bold text-gray-800 text-lg">
                                                {(game.averageRating / 2).toFixed(1).replace('.', ',')}
                                            </span>
                                            <span className="text-gray-500 text-sm font-medium ml-0.5">
                                                ({game.reviewsCount})
                                            </span>
                                        </div>
                                    </div>

                                    <div className="rounded-lg overflow-hidden mb-5 aspect-3/4 bg-gray-100">
                                        <img src={game.image} alt={game.title} className="w-full h-full object-cover" />
                                    </div>

                                    <p className="text-gray-600 text-sm leading-relaxed mb-6">{game.description}</p>

                                    <div className="space-y-2 text-sm">
                                        <div className="flex">
                                            <span className="font-bold text-gray-900 w-36">Ano:</span>
                                            <span className="text-gray-700">{game.year}</span>
                                        </div>
                                        <div className="flex">
                                            <span className="font-bold text-gray-900 w-36">Desenvolvedor(es):</span>
                                            <span className="text-gray-700">{game.developers.join(', ')}</span>
                                        </div>
                                        <div className="flex">
                                            <span className="font-bold text-gray-900 w-36">Publicador(as):</span>
                                            <span className="text-gray-700">{game.publishers.join(', ')}</span>
                                        </div>
                                        <div className="flex">
                                            <span className="font-bold text-gray-900 w-36">Gêneros:</span>
                                            <span className="text-gray-700">{game.categories.join(', ')}</span>
                                        </div>
                                    </div>
                                </>
                            )}
                            {!game && <Loader color="violet" className="mx-auto" />}
                        </div>
                    </div>

                    <div className="flex-1 w-full space-y-6">
                        <div className="bg-white rounded-lg border border-gray-200 shadow-sm p-6">
                            <form onSubmit={handleSubmit(onSubmit)}>
                                <Textarea
                                    placeholder="Insira seu comentário (opcional)..."
                                    classNames={{
                                        input: 'focus:outline-none focus:ring-1 focus:ring-purple-500 focus:border-purple-500 min-h-16 mb-4',
                                    }}
                                    autosize
                                    minRows={6}
                                    // resize="vertical"
                                    {...register('comment')}
                                    disabled={!!userReview}
                                    defaultValue={userReview?.comment}
                                />

                                <div className="flex justify-end items-center gap-4">
                                    <div className="flex gap-1">
                                        <Rating
                                            fractions={2}
                                            // value * 2 no momento por conta do backend aceitar um int de 1 a 10
                                            onChange={(value) => setValue('score', value * 2)}
                                            size={24}
                                            readOnly={!!userReview}
                                            defaultValue={(userReview?.score ?? 0) / 2}
                                        />
                                    </div>

                                    <Button
                                        color="violet"
                                        w={120}
                                        type="submit"
                                        disabled={ratings?.some((rating) => rating.isMine)}
                                    >
                                        Enviar
                                    </Button>
                                </div>
                            </form>
                        </div>

                        <div className="space-y-4 pb-4">
                            {ratings && ratings.length > 0 ? (
                                ratings.map((rating) => (
                                    <div
                                        key={rating.id}
                                        className="bg-white rounded-lg border border-gray-200 shadow-sm p-6"
                                    >
                                        <div className="flex justify-between items-start mb-2">
                                            <div className="flex items-center gap-3">
                                                <div className="w-10 h-10 rounded-full border border-purple-600 flex items-center justify-center text-purple-600">
                                                    <User size={24} strokeWidth={1.5} />
                                                </div>
                                                <div>
                                                    <h4 className="font-bold text-gray-900 text-sm">
                                                        {rating.userNickname}
                                                    </h4>
                                                    <Rating size="md" readOnly value={rating.score / 2} fractions={2} />
                                                </div>
                                            </div>
                                            <div className="flex items-center gap-4">
                                                <span className="text-gray-500 text-xs italic">
                                                    {new Date(rating.reviewDate).toLocaleDateString('pt-BR', {
                                                        day: 'numeric',
                                                        month: 'short',
                                                        year: 'numeric',
                                                        hour: '2-digit',
                                                        minute: '2-digit',
                                                    })}
                                                </span>
                                                {rating.isMine && (
                                                    <button
                                                        onClick={() =>
                                                            deleteRating.mutateAsync({ gameId, id: rating.id })
                                                        }
                                                        className="text-gray-400 hover:text-red-600 transition-colors"
                                                        title="Excluir avaliação"
                                                    >
                                                        <Trash2 size={16} />
                                                    </button>
                                                )}
                                            </div>
                                        </div>
                                        {rating.comment && (
                                            <p className="text-gray-700 text-sm leading-relaxed mt-3">
                                                {rating.comment}
                                            </p>
                                        )}
                                    </div>
                                ))
                            ) : (
                                <div className="text-center text-gray-500 py-10 bg-white rounded-lg border border-gray-200 border-dashed">
                                    {isRatingsLoading ? <Loader color="violet" /> : 'Nenhuma avaliação encontrada.'}
                                </div>
                            )}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}
