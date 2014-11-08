class ArticlesController < ApplicationController
    # def new
        
    # end
    def create
        render plain: "sdfsdfsdf"
        # @article = Article.new(article_params)
        # @article.save
        # redirect_to @article
    end
     
    private
        def article_params
            # render plain: params[:article].inspect
            params.require(:article).permit(:title, :text)
        end
end
